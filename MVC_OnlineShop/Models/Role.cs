namespace MVC_OnlineShop.Models {
    public class Role {

        /// <summary>
        /// Can be used for checking if Cx has access to page
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Display name for the role
        /// </summary>
        public string Name { get; set; } 
    }
}