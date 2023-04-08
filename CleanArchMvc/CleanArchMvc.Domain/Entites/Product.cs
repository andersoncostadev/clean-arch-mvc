using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entites
{
    public sealed class Product: Entity
    {
        public Product(string name, string description, decimal price, int stock, string image)
        {
            validateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id= id;
            validateDomain(name, description, price, stock, image);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int  CatgoryId { get; set; }
        public Category Category { get; set; }

        private void validateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 charecteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required!");

            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 charecteres");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When( stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image, too short, minimum 250 charecteres");

            Name= name;
            Description= description;
            Price= price;
            Stock= stock;
            Image= image;
        }

        public void UpdateProduct(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            validateDomain(name, description, price, stock, image);
            CatgoryId = categoryId;
        }
    }
}
