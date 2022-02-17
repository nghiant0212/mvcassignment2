using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_ASP.NET_MVC2.Models;
using System.Net;

namespace Assignment_ASP.NET_MVC2.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public static List<PersonModel> people = new List<PersonModel>
    {
            new PersonModel
            {
                Id = 1,
                FirstName = "Firstname1",
                LastName = "Lastname1",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 12, 2),
                PhoneNumber = "0123456789",
                BirthPlace = "Hanoi",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = 2,                
                FirstName = "Firstname2",
                LastName = "Lastname2",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 12, 2),
                PhoneNumber = "0123456789",
                BirthPlace = "Hanoi",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = 3,
                FirstName = "Firstname3",
                LastName = "Lastname3",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 11, 2),
                PhoneNumber = "0123456789",
                BirthPlace = "Hanoi",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = 4,
                FirstName = "Firstname4",
                LastName = "Lastname4",
                Gender = "Female",
                DateOfBirth = new DateTime(1999, 11, 2),
                PhoneNumber = "0123456789",
                BirthPlace = "Hanoi",
                IsGraduated = true
            },
            new PersonModel
            {
                Id = 5,
                FirstName = "Firstname5",
                LastName = "Lastname5",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 11, 2),
                PhoneNumber = "0123456789",
                BirthPlace = "Hanoi",
                IsGraduated = true
            }
        };
    public IActionResult Index()
    {
        return View(people);
    }

    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(PersonModel person)
    {
        var newPerson = new PersonModel
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender,
            DateOfBirth = person.DateOfBirth,
            PhoneNumber = person.PhoneNumber,
            BirthPlace = person.BirthPlace
        };
        people.Add(newPerson);
        return RedirectToAction("Index");
        // return Content($"Name: {person.FirstName} {person.LastName}, Gender: {person.Gender}");
    }
    public IActionResult Edit(int id)
    {
        var person = (from per in people
                    where per.Id == id
                    select per).ToList().First();
        // var person = people.Where(x=>x.)
        if(person!=null)
        {
            return View(person);
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Edit(PersonModel person)
    {
        // var editPerson = (from per in people
        //             where per.Id == person.Id
        //             select per).ToList().First();
        var editPerson = people.Where(x=>x.Id == person.Id).FirstOrDefault();
        if(editPerson!=null)
        {
            editPerson.LastName = person.LastName;
            editPerson.FirstName = person.FirstName;
            editPerson.Gender = person.Gender;
            editPerson.DateOfBirth = person.DateOfBirth;
            editPerson.PhoneNumber = person.PhoneNumber;
            editPerson.BirthPlace = person.BirthPlace;
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var deletePerson = people.Where(x=>x.Id == id).FirstOrDefault();
        if(deletePerson!=null)
        {
            if(people.Remove(deletePerson))
                return Ok();
        }
        return NotFound();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
