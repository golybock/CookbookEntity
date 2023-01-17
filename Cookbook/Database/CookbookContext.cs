using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Database;

public partial class CookbookContext : DbContext
{
    public CookbookContext()
    {
    }

    public CookbookContext(DbContextOptions<CookbookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientImage> ClientImages { get; set; }

    public virtual DbSet<ClientSub> ClientSubs { get; set; }

    public virtual DbSet<FavoriteRecipe> FavoriteRecipes { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Measure> Measures { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }

    public virtual DbSet<RecipeImage> RecipeImages { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeStat> RecipeStats { get; set; }

    public virtual DbSet<RecipeType> RecipeTypes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewImage> ReviewImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=127.0.0.1;port=5432;Username=admin;Password=admin;Database=Cookbook;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.HasIndex(e => e.Name, "category_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.HasIndex(e => e.Login, "client_login_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfRegistration)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_registration");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Login)
                .HasMaxLength(150)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .HasColumnName("password");
        });

        modelBuilder.Entity<ClientImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_images_pkey");

            entity.ToTable("client_images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateOfAdded)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_added");
            entity.Property(e => e.ImagePath).HasColumnName("image_path");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientImages)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_fk");
        });

        modelBuilder.Entity<ClientSub>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_subs_pkey");

            entity.ToTable("client_subs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateOfSub)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_sub");
            entity.Property(e => e.Sub).HasColumnName("sub");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientSubClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_fk");

            entity.HasOne(d => d.SubNavigation).WithMany(p => p.ClientSubSubNavigations)
                .HasForeignKey(d => d.Sub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sub_fk");
        });

        modelBuilder.Entity<FavoriteRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("favorite_recipes_pkey");

            entity.ToTable("favorite_recipes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateOfAdding)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_adding");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Client).WithMany(p => p.FavoriteRecipes)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_fk");

            entity.HasOne(d => d.Recipe).WithMany(p => p.FavoriteRecipes)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_fk");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ingredient_pkey");

            entity.ToTable("ingredient");

            entity.HasIndex(e => e.Name, "ingredient_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImagePath).HasColumnName("image_path");
            entity.Property(e => e.MeasureId).HasColumnName("measure_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");

            entity.HasOne(d => d.Measure).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.MeasureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("measure_fk");
        });

        modelBuilder.Entity<Measure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("measure_pkey");

            entity.ToTable("measure");

            entity.HasIndex(e => e.Name, "measure_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_pkey");

            entity.ToTable("recipe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CookingTime).HasColumnName("cooking_time");
            entity.Property(e => e.DateOfCreation)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_creation");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.PathToTextFile).HasColumnName("path_to_text_file");
            entity.Property(e => e.PortionCount)
                .HasDefaultValueSql("1")
                .HasColumnName("portion_count");
            entity.Property(e => e.RecipeTypeId).HasColumnName("recipe_type_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_fk");

            entity.HasOne(d => d.RecipeType).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.RecipeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_type_fk");
        });

        modelBuilder.Entity<RecipeCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_categories_pkey");

            entity.ToTable("recipe_categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Category).WithMany(p => p.RecipeCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("category_fk");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeCategories)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_fk");
        });

        modelBuilder.Entity<RecipeImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_images_pkey");

            entity.ToTable("recipe_images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageNumber).HasColumnName("image_number");
            entity.Property(e => e.ImagePath).HasColumnName("image_path");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_ingredients_pkey");

            entity.ToTable("recipe_ingredients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count)
                .HasDefaultValueSql("1")
                .HasColumnName("count");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingredient_fk");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_fk");
        });

        modelBuilder.Entity<RecipeStat>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("recipe_stats_pkey");

            entity.ToTable("recipe_stats");

            entity.Property(e => e.RecipeId)
                .ValueGeneratedNever()
                .HasColumnName("recipe_id");
            entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");
            entity.Property(e => e.Fats).HasColumnName("fats");
            entity.Property(e => e.Kilocalories).HasColumnName("kilocalories");
            entity.Property(e => e.Squirrels).HasColumnName("squirrels");

            entity.HasOne(d => d.Recipe).WithOne(p => p.RecipeStat)
                .HasForeignKey<RecipeStat>(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_fk");
        });

        modelBuilder.Entity<RecipeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recipe_type_pkey");

            entity.ToTable("recipe_type");

            entity.HasIndex(e => e.Name, "recipe_type_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("review_pkey");

            entity.ToTable("review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateOfAdding)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_adding");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.IsAnonymous).HasColumnName("is_anonymous");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_fk");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_fk");
        });

        modelBuilder.Entity<ReviewImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("review_images_pkey");

            entity.ToTable("review_images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImagePath).HasColumnName("image_path");
            entity.Property(e => e.ReviewId).HasColumnName("review_id");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewImages)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("review_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
