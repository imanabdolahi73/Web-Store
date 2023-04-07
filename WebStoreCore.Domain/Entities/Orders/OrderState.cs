﻿using System.ComponentModel.DataAnnotations;

namespace WebStoreCore.Domain.Entities.Orders
{
    public enum OrderState
    {
        [Display(Name ="در حال پردازش")]
        Processing = 0,
        [Display(Name ="لغو شده")]
        Canceled = 1,
        [Display(Name ="تحویل داده شده")]
        Delivered = 2,
    }

}
