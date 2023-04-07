using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreCore.Application.Interfaces.Contexts;
using WebStoreCore.Comon;
using static WebStoreCore.Application.Services.Users.Queries.GetUsers.GetUsersService;

namespace WebStoreCore.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ReslutGetUserDto Execute(RequestGetUserDto request, int Page = 1, int PageSize = 20);
    }
    public class RequestGetUserDto
    {
        public string SearchKey { get; set; }
        public int Rows { get; set; }

    }

    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }

        public ReslutGetUserDto Execute(RequestGetUserDto request, int Page = 1, int PageSize = 20)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) || p.Email.Contains(request.SearchKey));
            }
            int rowsCount = 0;
            var usersList = users.ToPaged(request.Rows, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
                IsActive = p.IsActive
            }).ToList();

            return new ReslutGetUserDto
            {
                CurrentPage = Page,
                PageSize = PageSize,
                RowCount = rowsCount,
                Users = usersList,
            };
        }

    }

    public class GetUsersDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

    }
    public class ReslutGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int RowCount { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

    }

}
