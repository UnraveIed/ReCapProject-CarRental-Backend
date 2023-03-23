using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework.Contexts;
using CarRental.DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete
{
    //public class UnitOfWork : IUnitOfWork
    //public class UnitOfWork
    //{
    //    private readonly CarRentalContext _context;

    //    public UnitOfWork(CarRentalContext context)
    //    {
    //        _context = context;
    //    }

    //    private EfBrandRepository _brandRepository;
    //    private EfCarRepository _carRepository;
    //    private EfColorRepository _colorRepository;
    //    private EfUserRepository _userRepository;
    //    private EfRentalRepository _rentalRepository;
    //    private EfCustomerRepository _customerRepository;
    //    //public IBrandRepository Brands => _brandRepository ??= new EfBrandRepository(_context);
    //    public IBrandRepository Brands => _brandRepository ??= new EfBrandRepository();

    //    //public ICarRepository Cars => _carRepository ??= new EfCarRepository(_context);
    //    public ICarRepository Cars => _carRepository ??= new EfCarRepository();

    //    //public IColorRepository Colors => _colorRepository ??= new EfColorRepository(_context);
    //    public IColorRepository Colors => _colorRepository ??= new EfColorRepository();

    //    //public IUserRepository Users => _userRepository ??= new EfUserRepository(_context);
    //    public IUserRepository Users => _userRepository ??= new EfUserRepository();

    //    //public IRentalRepository Rentals => _rentalRepository ??= new EfRentalRepository(_context);
    //    public IRentalRepository Rentals => _rentalRepository ??= new EfRentalRepository();

    //    //public ICustomerRepository Customers => _customerRepository ??= new EfCustomerRepository(_context);
    //    public ICustomerRepository Customers => _customerRepository ??= new EfCustomerRepository();

    //    public async ValueTask DisposeAsync()
    //    {
    //        await _context.DisposeAsync();
    //    }

    //    public async Task<int> SaveAsync()
    //    {
    //        return await _context.SaveChangesAsync();
    //    }
    //}
}
