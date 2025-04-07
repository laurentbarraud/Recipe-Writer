BEGIN TRANSACTION;
DROP TABLE IF EXISTS "Ingredients";
CREATE TABLE "Ingredients" (
	"id"	INTEGER NOT NULL,
	"ingredientName_en"	TEXT,
	"ingredientName_fr"	TEXT NOT NULL,
	"qtyAvailable"	REAL NOT NULL,
	"scale_id"	INTEGER NOT NULL,
	"typeOfIngredient_id"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("scale_id") REFERENCES "Scales"("id"),
	FOREIGN KEY("typeOfIngredient_id") REFERENCES "TypesOfIngredient"("id")
);
DROP TABLE IF EXISTS "Instructions";
CREATE TABLE "Instructions" (
	"id"	INTEGER NOT NULL,
	"instruction"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "Instructions_has_Recipes";
CREATE TABLE "Instructions_has_Recipes" (
	"id"	INTEGER NOT NULL,
	"Recipes_id"	INTEGER NOT NULL,
	"Instructions_id"	INTEGER NOT NULL,
	"InstructionNb"	INTEGER NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("Instructions_id") REFERENCES "Instructions" ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY("Recipes_id") REFERENCES "Recipes" ON UPDATE CASCADE ON DELETE CASCADE
);
DROP TABLE IF EXISTS "PlannedMeals";
CREATE TABLE "PlannedMeals" (
	"id"	INTEGER NOT NULL,
	"titleOfPlannedRecipe"	TEXT,
	"dayOfTheWeek"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "Recipes";
CREATE TABLE "Recipes" (
	"id"	INTEGER NOT NULL,
	"title"	TEXT NOT NULL,
	"completionTime"	INTEGER NOT NULL,
	"lowBudget"	INTEGER NOT NULL,
	"score"	INTEGER NOT NULL,
	"imagePath"	TEXT NOT NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "Recipes_has_Ingredients";
CREATE TABLE "Recipes_has_Ingredients" (
	"id"	INTEGER NOT NULL,
	"qtyIngredient1"	REAL,
	"qtyIngredient2"	REAL,
	"qtyIngredient3"	REAL,
	"qtyIngredient4"	REAL,
	"qtyIngredient5"	REAL,
	"qtyIngredient6"	REAL,
	"qtyIngredient7"	REAL,
	"qtyIngredient8"	REAL,
	"qtyIngredient9"	REAL,
	"qtyIngredient10"	REAL,
	"qtyIngredient11"	REAL,
	"qtyIngredient12"	REAL,
	"qtyIngredient13"	REAL,
	"qtyIngredient14"	REAL,
	"qtyIngredient15"	REAL,
	"qtyIngredient16"	REAL,
	"qtyIngredient17"	REAL,
	"qtyIngredient18"	REAL,
	"qtyIngredient19"	REAL,
	"qtyIngredient20"	REAL,
	"ingredient1_id"	INTEGER,
	"ingredient2_id"	INTEGER,
	"ingredient3_id"	INTEGER,
	"ingredient4_id"	INTEGER,
	"ingredient5_id"	INTEGER,
	"ingredient6_id"	INTEGER,
	"ingredient7_id"	INTEGER,
	"ingredient8_id"	INTEGER,
	"ingredient9_id"	INTEGER,
	"ingredient10_id"	INTEGER,
	"ingredient11_id"	INTEGER,
	"ingredient12_id"	INTEGER,
	"ingredient13_id"	INTEGER,
	"ingredient14_id"	INTEGER,
	"ingredient15_id"	INTEGER,
	"ingredient16_id"	INTEGER,
	"ingredient17_id"	INTEGER,
	"ingredient18_id"	INTEGER,
	"ingredient19_id"	INTEGER,
	"ingredient20_id"	INTEGER,
	"scales1_id"	INTEGER,
	"scales2_id"	INTEGER,
	"scales3_id"	INTEGER,
	"scales4_id"	INTEGER,
	"scales5_id"	INTEGER,
	"scales6_id"	INTEGER,
	"scales7_id"	INTEGER,
	"scales8_id"	INTEGER,
	"scales9_id"	INTEGER,
	"scales10_id"	INTEGER,
	"scales11_id"	INTEGER,
	"scales12_id"	INTEGER,
	"scales13_id"	INTEGER,
	"scales14_id"	INTEGER,
	"scales15_id"	INTEGER,
	"scales16_id"	INTEGER,
	"scales17_id"	INTEGER,
	"scales18_id"	INTEGER,
	"scales19_id"	INTEGER,
	"scales20_id"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT),
	FOREIGN KEY("ingredient10_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient11_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient12_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient13_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient14_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient15_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient16_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient17_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient18_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient19_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient1_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient20_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient2_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient3_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient4_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient5_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient6_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient7_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient8_id") REFERENCES "Ingredients",
	FOREIGN KEY("ingredient9_id") REFERENCES "Ingredients",
	FOREIGN KEY("scales10_id") REFERENCES "Scales",
	FOREIGN KEY("scales11_id") REFERENCES "Scales",
	FOREIGN KEY("scales12_id") REFERENCES "Scales",
	FOREIGN KEY("scales13_id") REFERENCES "Scales",
	FOREIGN KEY("scales14_id") REFERENCES "Scales",
	FOREIGN KEY("scales15_id") REFERENCES "Scales",
	FOREIGN KEY("scales16_id") REFERENCES "Scales",
	FOREIGN KEY("scales17_id") REFERENCES "Scales",
	FOREIGN KEY("scales18_id") REFERENCES "Scales",
	FOREIGN KEY("scales19_id") REFERENCES "Scales",
	FOREIGN KEY("scales1_id") REFERENCES "Scales",
	FOREIGN KEY("scales20_id") REFERENCES "Scales",
	FOREIGN KEY("scales2_id") REFERENCES "Scales",
	FOREIGN KEY("scales3_id") REFERENCES "Scales",
	FOREIGN KEY("scales4_id") REFERENCES "Scales",
	FOREIGN KEY("scales5_id") REFERENCES "Scales",
	FOREIGN KEY("scales6_id") REFERENCES "Scales",
	FOREIGN KEY("scales7_id") REFERENCES "Scales",
	FOREIGN KEY("scales8_id") REFERENCES "Scales",
	FOREIGN KEY("scales9_id") REFERENCES "Scales"
);
DROP TABLE IF EXISTS "Scales";
CREATE TABLE "Scales" (
	"id"	INTEGER NOT NULL,
	"scaleName_en"	TEXT,
	"scaleName_fr"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "TypesOfIngredient";
CREATE TABLE "TypesOfIngredient" (
	"id"	INTEGER,
	"type_en"	TEXT,
	"type_fr"	TEXT,
	PRIMARY KEY("id" AUTOINCREMENT)
);
COMMIT;
