using WebStoreCore.Application.Interfaces.Contexts;
using WebStoreCore.Comon.Dto;
using WebStoreCore.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreCore.Application.Services.Common.Queries.GetSlider
{
    public interface IGetSliderService
    {
        ResultDto<List<SliderDto>> Execute();
    }

    public class GetSliderService : IGetSliderService
    {
        private readonly IDataBaseContext _context;
        public GetSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var sliders = _context.Sliders.OrderByDescending(p => p.Id).ToList().Select(
                p => new SliderDto
                {
                    Link=p.link,
                    Src=p.Src,
                }).ToList();

            return new ResultDto<List<SliderDto>>()
            {
                Data = sliders,
                IsSuccess = true,
            };
        }
    }

    public   class SliderDto
    {
        public string   Src { get; set; }
        public string   Link { get; set; }
    }
}
