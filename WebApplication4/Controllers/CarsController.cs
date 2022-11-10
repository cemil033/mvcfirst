using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> cars = new()
        {
            new Car(){Vendor="Ford",Model="Mustang",Year=2022},
            new Car(){Vendor="Porsche",Model="Cayenne",Year=2021},
            new Car(){Vendor="Porsche",Model="Macan",Year=2018},
            new Car(){Vendor="Porsche",Model="Panamera",Year=2012},
            new Car(){Vendor="Mercedes",Model="C240",Year=2022},
            new Car(){Vendor="Mercedes",Model="E240",Year=2021},
            new Car(){Vendor="BMW",Model="M5",Year=2005},
            new Car(){Vendor="BMW",Model="M3",Year=2021},
        };
        public IActionResult GetAll()
        {
            return View(cars);
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            cars.Add(car);
            return Redirect("GetAll");
        }
       
        public IActionResult Delete()
        {
            var model = new CarsVM();
            cars.ForEach(a => model.Cars.Add(new SelectListItem { Value = a.Model, Text = a.Vendor + ' ' + a.Model + ' ' + a.Year }));
            return View(model);
            
        }

        [HttpPost]
        public IActionResult Delete(CarsVM carvm)
        {
            
            var cr = carvm.Car;
            Car car1=new();

            foreach (var item in cars)
            {
                if (item.Model == cr)
                {
                    car1 = item;
                }
            }
            cars.Remove(car1);
            return Redirect("GetAll");
        }
    }
}
