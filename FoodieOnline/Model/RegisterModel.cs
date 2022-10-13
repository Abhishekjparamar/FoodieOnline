namespace FoodieOnline.Model
{
    public class RegisterModel
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="User Name Is Required")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Password Cannot Be Empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone No Is Required")]
        public string Phone { get; set; }

    }

}
