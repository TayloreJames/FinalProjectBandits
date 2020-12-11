using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBandits.Data;
using FinalProjectBandits.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Differencing;

namespace FinalProjectBandits.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            //[DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string First_Name { get; set; }

            [Required]
            //[DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string Last_Name { get; set; }

            [Required]
            //[DataType(DataType.Text)]
            [Display(Name = "Street")]
            public string Street { get; set; }

            [Required]
            //[DataType(DataType.Text)]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            //[DataType(DataType.Text)]
            [Display(Name = "State")]
            public string State { get; set; }

            [Required]
            //[DataType(DataType.Text)]
            [Display(Name = "Zip")]
            public string Zip { get; set; }

            [Required]
            //[DataType(DataType.Text)]
            [Display(Name = "Phone")]
            public string Phone { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            Username = userName;
            var currentCustomer = _dbContext.Customers.First(c => c.UserId == user.Id);

            Input = new InputModel
            {
                //PhoneNumber = phoneNumber,
                First_Name = currentCustomer.First_Name,
                Last_Name = currentCustomer.Last_Name,
                Street = currentCustomer.Street,
                City = currentCustomer.City,
                State = currentCustomer.State,
                Zip = currentCustomer.Zip,
                Phone = currentCustomer.Phone,
                Email = currentCustomer.Email,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var currentCustomer = _dbContext.Customers.First(c => c.UserId == user.Id);
            currentCustomer.First_Name = Input.First_Name;
            currentCustomer.Last_Name = Input.Last_Name;
            currentCustomer.Street = Input.Street;
            currentCustomer.City = Input.City;
            currentCustomer.State = Input.State;
            currentCustomer.Zip = Input.Zip;
            currentCustomer.Phone = Input.Phone;
            currentCustomer.Email = Input.Email;
            //add remaining

            await _dbContext.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
