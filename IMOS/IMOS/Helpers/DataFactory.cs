using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using IMOS.Models;
using IMOS.DbLocal;

namespace IMOS.Helpers
{
    public static class DataFactory
    {
        public static IList<MenuLateral> DataItems { get; private set; }

        private static readonly Category Venta = new Category { CategoryId = 1, CategoryTitle = "Ventas" };
        private static readonly Category Clientes = new Category { CategoryId = 2, CategoryTitle = "Clientes" };
        private static readonly Category Reportes = new Category { CategoryId = 3, CategoryTitle = "Reportes" };

        static DataFactory()
        {
            LoadDataFactory();
        }
        public static void LoadDataFactory()
        {
            var db = new DbContext();
            var ventas = db.SearchDiaAbierto();
            if(ventas > 0)
            {
                DataItems = new ObservableCollection<MenuLateral>()
                {
                    new MenuLateral
                    {
                        ItemId = 1,
                        ItemTitle = "Abrir dia",
                        Validate = false,
                        Category = Venta
                    },
                    new MenuLateral
                    {
                        ItemId = 2,
                        ItemTitle = "Cerrar dia",
                        Validate = true,
                        Category = Venta
                    },
                    new MenuLateral
                    {
                        ItemId = 3,
                        ItemTitle = "Consultar",
                        Validate = true,
                        Category = Clientes
                    },
                    new MenuLateral
                    {
                        ItemId = 4,
                        ItemTitle = "Crear nuevo cliente",
                        Validate = true,
                        Category = Clientes
                    }
                    ,
                    new MenuLateral
                    {
                        ItemId = 5,
                        ItemTitle = "Ventas",
                        Validate = true,
                        Category = Reportes
                    },
                    new MenuLateral
                    {
                        ItemId = 6,
                        ItemTitle = "Cobranza",
                        Validate = true,
                        Category = Reportes
                    },
                    new MenuLateral
                    {
                        ItemId = 7,
                        ItemTitle = "Inventario",
                        Validate = true,
                        Category = Reportes
                    }
                };
            }
            else
            {
                DataItems = new ObservableCollection<MenuLateral>()
                {
                    new MenuLateral
                    {
                        ItemId = 1,
                        ItemTitle = "Abrir dia",
                        Validate = true,
                        Category = Venta
                    },
                    new MenuLateral
                    {
                        ItemId = 2,
                        ItemTitle = "Cerrar dia",
                        Validate = false,
                        Category = Venta
                    },
                    new MenuLateral
                    {
                        ItemId = 3,
                        ItemTitle = "Consultar",
                        Validate = false,
                        Category = Clientes
                    },
                    new MenuLateral
                    {
                        ItemId = 4,
                        ItemTitle = "Crear nuevo cliente",
                        Validate = false,
                        Category = Clientes
                    }
                    ,
                    new MenuLateral
                    {
                        ItemId = 5,
                        ItemTitle = "Ventas",
                        Validate = false,
                        Category = Reportes
                    },
                    new MenuLateral
                    {
                        ItemId = 6,
                        ItemTitle = "Cobranza",
                        Validate = false,
                        Category = Reportes
                    },
                    new MenuLateral
                    {
                        ItemId = 7,
                        ItemTitle = "Inventario",
                        Validate = false,
                        Category = Reportes
                    }
                };
            }
        }
    }
}
