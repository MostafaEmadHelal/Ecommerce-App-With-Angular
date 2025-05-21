using AutoMapper;
using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageManagementService _iImageManagementService;
        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IPhotoRepository photoRepository { get; }


        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagementService iImageManagementService)
        {
            _context = context;
            _mapper = mapper;
            _iImageManagementService = iImageManagementService;

            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context,_mapper,_iImageManagementService);
            photoRepository = new PhotoRepository(_context);
        }
    }
}
