﻿using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entites
{
    public sealed class Category : Entity
    {
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id= id;
            ValidateDomain(name);
        }

        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required!");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 charecteres");

            Name = name;
        }

        public void UpdateCategory(string name)
        {
            ValidateDomain(name);
        }
    }
}
