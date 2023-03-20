using prod.Models;
using prod.Data;
using Microsoft.EntityFrameworkCore;
using NT.Common.DataAccess;
using AutoMapper;
using prod.ViewModel;

namespace prod.Services;

public class prodService
{
    private readonly IMapper _mapper;
    private readonly IUowProvider _uowProvider;
    private readonly prodContext _context;
    public prodService(prodContext context, IUowProvider uowProvider, IMapper mapper)
    {
        _context = context;
        _uowProvider = uowProvider;
        _mapper = mapper;
    }

    public List<Product> GetAll()
    {
        // return _context.Products
        //     .AsNoTracking()
        //     .ToList();
        using(var uow = _uowProvider.CreateUnitOfWork())
        {
            var repo = uow.GetRepository<Product>();
            // normally we query with condition isDelete == false
            var result = repo.Filters(x => x.is_deleted == false).ToList();
            return _mapper.Map<List<Product>>(result);
        }
    }

    public Product? GetById(int id)
    {
        using (var uow = _uowProvider.CreateUnitOfWork())
        {
            var repo = uow.GetRepository<Product>();
            var product = repo.Filters(x => x.id == id && x.is_deleted == false).FirstOrDefault();
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return _mapper.Map<Product>(product);
        }
        // return _context.Products
        //     .Include(p => p.Category)
        //     .AsNoTracking()
        //     .SingleOrDefault(p => p.id ==id);
    }

    // normally return a response view model
    public Product? Create(ProductRequestViewModel newProduct)
    {
        using (var uow = _uowProvider.CreateUnitOfWork())
        {
            var repo = uow.GetRepository<Product>();
            var insertProduct = this._mapper.Map<Product>(newProduct);
            repo?.Add(insertProduct);
            uow?.SaveChanges();
            return this._mapper.Map<Product>(insertProduct);
        }
    }

    public bool Update(int id, ProductRequestViewModel Product)
    {
        using (var uow = _uowProvider.CreateUnitOfWork())
        {
            var repo = uow.GetRepository<Product>();
            var existingProduct = repo.GetActive(id);

            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }
            
            existingProduct = _mapper.Map<ProductRequestViewModel, Product>(Product, existingProduct);
            uow.SaveChanges();
            return true;
        }
        // var productToUpdate = _context.Products.Find(productId);
        // var categoryToUpdate = _context.Categories.Find(categoryId);

        // if (productToUpdate is null || categoryToUpdate is null)
        // {
        //     throw new InvalidOperationException("Product or category does not exist");
        // }

        // productToUpdate.Category = categoryToUpdate;

        // _context.SaveChanges();
    }

    public bool Delete(int id)
    {
        using (var uow = _uowProvider.CreateUnitOfWork())
        {
            var repo = uow.GetRepository<Product>();
            var existingProduct = repo.GetActive(id);

            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            existingProduct.is_deleted = true;
            uow.SaveChanges();

            return true;
        }
        // var productToDelete = _context.Products.Find(id);
        // if (productToDelete is not null)
        // {
        //     _context.Products.Remove(productToDelete);
        //     _context.SaveChanges();
        // }
    }
}