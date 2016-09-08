using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
namespace SportsStore.Web.Binders
{
    public class CartModelBindeer : IModelBinder
    {
        private const string SessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext modelBindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                 cart = (Cart)controllerContext.HttpContext.Session[SessionKey];
            }
            if (cart == null)
                {
                    cart = new Cart();
                    controllerContext.HttpContext.Session[SessionKey] = cart;
                }
                return cart;
            }
    }
}