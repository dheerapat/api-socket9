using prod.Models;
using prod.Data;
using Microsoft.EntityFrameworkCore;
using NT.Common.DataAccess;
using AutoMapper;

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
            // normally we query with condition isDelete == true
            var result = repo.Filters(x => x.Id > 0).ToList();
            return _mapper.Map<List<Product>>(result);
        }
    }

    public Product? GetById(int id)
    {
        return _context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id ==id);
    }

    public Product? Create(Product newProduct)
    {
        _context.Products.Add(newProduct);
        _context.SaveChanges();

        return newProduct;
    }

    public void UpdateCategory(int productId, int categoryId)
    {
        var productToUpdate = _context.Products.Find(productId);
        var categoryToUpdate = _context.Categories.Find(categoryId);

        if (productToUpdate is null || categoryToUpdate is null)
        {
            throw new InvalidOperationException("Product or category does not exist");
        }

        productToUpdate.Category = categoryToUpdate;

        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var productToDelete = _context.Products.Find(id);
        if (productToDelete is not null)
        {
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
        }
    }
}