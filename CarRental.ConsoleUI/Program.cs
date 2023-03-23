// See https://aka.ms/new-console-template for more information
using CarRental.Business.Concrete;
using CarRental.DataAccess.Concrete;
using CarRental.DataAccess.Concrete.EntityFramework.Repositories;
using CarRental.Entities.Concrete;

CarManager car = new(new EfCarRepository());
ColorManager c = new(new EfColorRepository());
BrandManager b = new(new EfBrandRepository());

//await CarOperations(car);
//await ColorOperations(c);
//await BrandOperations(b);
//await car.GetAllAsync().Data;

var list = await car.GetAllCarDetail();

foreach (var item in list.Data)
{
    Console.WriteLine(item.CarId);
    Console.WriteLine(item.ColorName);
    Console.WriteLine(item.BrandName);
    Console.WriteLine(item.DailyPrice);
}


static async Task CarOperations(CarManager car)
{
    Car car1 = new()
    {
        BrandId = 2,
        ColorId = 3,
        DailyPrice = 245000.00M,
        Description = "Kullanisli",
        ModelYear = 2005,
    };

    var addedCar = await car.AddAsync(car1);
    Console.WriteLine(addedCar.Data.Description + " eklendi");


    var updateCar = car1;
    car1.Description = "Degisti";
    var updatedCar = await car.UpdateAsync(updateCar);
    Console.WriteLine(updatedCar.Data.Description + " guncellendi");

    await car.HardDeleteAsync(updatedCar.Data);
}

static async Task ColorOperations(ColorManager c)
{
    Color color1 = new()
    {
        Name = "Yesil"
    };

    var addedColor = await c.AddAsync(color1);
    Console.WriteLine(addedColor.Data.Name + " eklendi");

    var updateColor = addedColor;
    updateColor.Data.Name = "Yeşils";
    var updatedColor = await c.UpdateAsync(updateColor.Data);
    Console.WriteLine(updatedColor.Data.Name + " guncellendi");

    await c.HardDeleteAsync(updatedColor.Data);
}

static async Task BrandOperations(BrandManager b)
{
    Brand brand1 = new()
    {
        Name = "Toyota"
    };

    var addedBrand = await b.AddAsync(brand1);
    Console.WriteLine(addedBrand.Data.Name + " eklendi");


    var updateBrand = brand1;
    brand1.Name = "Degisti";
    var updatedBrand = await b.UpdateAsync(updateBrand);
    Console.WriteLine(updatedBrand.Data.Name + " guncellendi");

    await b.HardDeleteAsync(updatedBrand.Data);
}