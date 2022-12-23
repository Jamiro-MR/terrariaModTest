using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace espadaMalota.Items
{
	public class espadaMalota : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("espadaMalota"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("La espada custom más malota.");
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			Recipe recipe_alternate = CreateRecipe();
			recipe_alternate.AddRecipeGroup("Wood");
			recipe_alternate.AddIngredient(ItemID.Torch, 1);
			recipe_alternate.AddIngredient(ItemID.Wood, 10);
			recipe_alternate.AddTile(TileID.WorkBenches);
			recipe_alternate.Register();
		}
	}
}