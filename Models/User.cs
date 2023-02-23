using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class User
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Display(Name = "Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the profile photo.
        /// </summary>
        /// <value>The profile photo.</value>
        public byte[]? ProfilePhoto { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the mother identifier.
        /// </summary>
        /// <value>The mother identifier.</value>
        public int? MotherId { get; set; }

        /// <summary>
        /// Gets or sets the mother.
        /// </summary>
        /// <value>The mother.</value>
        //public virtual Parent? Mother { get; set; }

        /// <summary>
        /// Gets or sets the father identifier.
        /// </summary>
        /// <value>The father identifier.</value>
        public int? FatherId { get; set; }

        /// <summary>
        /// Gets or sets the father.
        /// </summary>
        /// <value>The father.</value>
        //public virtual Parent? Father { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        public int? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        //public virtual Group? Group { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        public int? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        //public virtual Role? Role { get; set; }

        /// <summary>
        /// Gets or sets the division identifier.
        /// </summary>
        /// <value>The division identifier.</value>
        public int? DivisionId { get; set; }

        /// <summary>
        /// Gets or sets the division.
        /// </summary>
        /// <value>The division.</value>
        //public virtual Division? Division { get; set; }
    }
}
