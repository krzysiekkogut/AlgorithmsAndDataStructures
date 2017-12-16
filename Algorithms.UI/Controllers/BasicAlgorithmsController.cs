using System;
using System.Linq;
using System.Web.Mvc;
using Algorithms.UI.Models;
using Implementations.Algorithms;

namespace Algorithms.UI.Controllers
{
    public class BasicAlgorithmsController : Controller
    {
        private BasicAlgorithms _basicAlgorithms;

        public BasicAlgorithmsController() : this(new BasicAlgorithms()) { }

        public BasicAlgorithmsController(BasicAlgorithms basicAlgorithms)
        {
            _basicAlgorithms = basicAlgorithms;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Min()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Min(string values)
        {
            try
            {
                var input = ConvertStringToIntArray(values);
                var result = _basicAlgorithms.Min(input);
                return PartialView(
                    "_Results",
                    new ResultsViewModel
                    {
                        Success = true,
                        Result = string.Format("{0}", result.ToString())
                    });
            }
            catch (Exception)
            {
                return PartialView("_Results", new ResultsViewModel { Success = false });
            }
        }

        [HttpGet]
        public ActionResult MinAndMax()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult MinAndMax(string values)
        {
            try
            {
                var input = ConvertStringToIntArray(values);
                var result = _basicAlgorithms.MinAndMax(input);
                return PartialView(
                    "_Results",
                    new ResultsViewModel
                    {
                        Success = true,
                        Result = string.Format("minimum {0}, maksimum {1}", result.Item1, result.Item2)
                    });
            }
            catch (Exception)
            {
                return PartialView("_Results", new ResultsViewModel { Success = false });
            }
        }

        [HttpGet]
        public ActionResult BinarySearch()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult BinarySearch(string values, int element)
        {
            try
            {
                var input = ConvertStringToIntArray(values);
                var result = _basicAlgorithms.BinarySearch(input, element);
                return PartialView(
                    "_Results",
                    new ResultsViewModel
                    {
                        Success = true,
                        Result = result == -1
                                    ? string.Format("elementu {0} nie ma w zbiorze", element)
                                    : string.Format("element {0} znajduje się na pozycji {1}", element, result)
                    });
            }
            catch (Exception)
            {
                return PartialView("_Results", new ResultsViewModel { Success = false });
            }
        }

        [HttpGet]
        public ActionResult Merge()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Merge(string first, string second)
        {
            try
            {
                var firstArray = ConvertStringToIntArray(first);
                var secondArray = ConvertStringToIntArray(second);
                var result = _basicAlgorithms.Merge(firstArray, secondArray);
                return PartialView(
                    "_Results",
                    new ResultsViewModel
                    {
                        Success = true,
                        Result = result
                                    .Select(x => x.ToString())
                                    .Aggregate((acc, next) => string.Format("{0}, {1}", acc, next))
                    });
            }
            catch (Exception)
            {
                return PartialView("_Results", new ResultsViewModel { Success = false });
            }
        }

        [HttpGet]
        public ActionResult RussianMultiplication()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult RussianMultiplication(string a, string b)
        {
            try
            {
                var result = _basicAlgorithms.RussianMultiplicate(Convert.ToInt64(a), Convert.ToInt64(b));
                return PartialView(
                    "_Results",
                    new ResultsViewModel
                    {
                        Success = true,
                        Result = result.ToString()
                    });
            }
            catch (Exception)
            {
                return PartialView("_Results", new ResultsViewModel { Success = false });
            }
        }

        [HttpGet]
        public ActionResult GCD()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult GCD(string a, string b)
        {
            try
            {
                var result = _basicAlgorithms.GCD(Convert.ToInt64(a), Convert.ToInt64(b));
                return PartialView(
                    "_Results",
                    new ResultsViewModel
                    {
                        Success = true,
                        Result = result.ToString()
                    });
            }
            catch (Exception)
            {
                return PartialView("_Results", new ResultsViewModel { Success = false });
            }
        }

        [HttpGet]
        public ActionResult FibonacciMatrix()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult FibonacciMatrix(string number)
        {
            try
            {
                var result = _basicAlgorithms.FibonacciNumber(Convert.ToInt32(number));
                return PartialView(
                    "_Results",
                    new ResultsViewModel
                    {
                        Success = true,
                        Result = string.Format("{0}", result.ToString())
                    });
            }
            catch (Exception)
            {
                return PartialView("_Results", new ResultsViewModel { Success = false });
            }
        }
        
        private int[] ConvertStringToIntArray(string str)
        {
            return str.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        }
    }
}