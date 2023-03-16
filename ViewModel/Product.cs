namespace prod.ViewModel{
    public class ProductViewModel
    {   
        public int Id { get; set; }
        public string? productName { get; set; }
        // public Category? Category { get; set; }
    }

    public class ProductRequestViewModel
    {
        public string productName { get; set; }
    }
}


