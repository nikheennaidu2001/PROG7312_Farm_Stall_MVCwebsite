using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prog_Farm_Stall_MVC_Final.Models;

namespace Prog_Farm_Stall_MVC_Final.Controllers
{
    public class LoginUsersController : Controller
    {
        private readonly Prog_Farm_Stall_MVC_FinalContext _context;

        public LoginUsersController(Prog_Farm_Stall_MVC_FinalContext context)
        {
            _context = context;
        }


        // GET: LoginUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoginUser.ToListAsync());
        }

        // GET: LoginUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginUser = await _context.LoginUser
                .FirstOrDefaultAsync(m => m.UsernameId == id);
            if (loginUser == null)
            {
                return NotFound();
            }

            return View(loginUser);
        }

        // GET: LoginUsers/Create
        public IActionResult Create()
        {
            return View();

        }

        // POST: LoginUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsernameId,Username,Password")] LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginUser);

        }


        //Shows the form for the Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //When we receive the data from the form
        [HttpPost]
        public ActionResult Login(LoginUser lu)
        {

            //Checks the database for matching user
            //Database object using the context taken from Models
            Prog_Farm_Stall_MVC_FinalContext db = new Prog_Farm_Stall_MVC_FinalContext();
            //Compares it to username and password in the database
            LoginUser users = db.LoginUser.Where(x => x.Username.Equals(lu.Username) && x.Password.Equals(lu.Password)).FirstOrDefault();

            //if statement
            if (users == null)
            {
                //No matching user
                //ViewBag
                ViewBag.LOGIN = "Failed";
                //Tell the user the login failed
                return View();
            }
            else
            {
                //Employees
                if (lu.Username == "nikheennaidu@farmstallemployee" && lu.Password == "120601")
                {
                    //Matching user
                    //Calls a specific view if its an employee
                    return RedirectToAction("Index", "LoginUsers");
                }

                if (lu.Username == "shailinpillay@farmstallemployee" && lu.Password == "050502")
                {
                    //Matching user
                    //Calls a specific view if its an employee
                    return RedirectToAction("Index", "LoginUsers");
                }

                //Farmers
                if (lu.Username == "tyriquepillay@farmstall" && lu.Password == "1234")
                {
                    //Matching user
                    //Calls a specific view if its a farmer
                    return RedirectToAction("Index", "Products");
                }

                if (lu.Username == "kealeennaicker@farmstall" && lu.Password == "4321")
                {
                    //Matching user
                    //Calls a specific view if its a farmer
                    return RedirectToAction("Index", "Products");
                }

                //All new users that are created are farmers
                else
                {
                    //Matching user
                    //Calls a specific view if its a farmer
                    return RedirectToAction("Index", "Products");
                }

            }

            return View();
        }
    }
}