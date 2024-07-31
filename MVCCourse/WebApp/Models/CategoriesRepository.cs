namespace WebApp.Models
{
	// Create an in-memory data store (static repository)
	public static class CategoriesRepository
	{
		private static List<Category> _categories = new List<Category>()
		{
			new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage"},
			new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery"},
			new Category { CategoryId = 4, Name = "Meat", Description = "Meat"}
		};

		// The create operation (C.R.U.D.)
		public static void AddCategory(Category category)
		{
			var maxId = _categories.Max(x => x.CategoryId);
			category.CategoryId = maxId + 1;
			_categories.Add(category);
		}

		public static List<Category> GetCategories() => _categories;

		// Read categories by ID
		public static Category? GetCategoryById(int categoryId)
		{
			var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
			if (category != null)
			{
				// Create a copy then return a copy
				return new Category
				{
					CategoryId = category.CategoryId,
					Name = category.Name,
					Description = category.Description,
				};
			}
			return null;
		}

		// Update categories
		public static void UpdateCategory(int categoryId, Category category)
		{
			if (categoryId != category.CategoryId) return;

			var categoryToUpdate = GetCategoryById(categoryId);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
			}
		}

		// Delete categories
		public static void DeleteCategory(int categoryId)
		{
			// Using link to get the categories
			var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
			if (category != null)
			{
				_categories.Remove(category);
			}
		}
	}
}
