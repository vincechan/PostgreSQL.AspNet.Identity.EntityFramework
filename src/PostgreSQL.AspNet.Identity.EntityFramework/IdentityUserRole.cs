namespace PostgreSQL.AspNet.Identity.EntityFramework {

	/// <summary>
	/// EntityType that represents a user belonging to a role
	/// </summary>
	public class IdentityUserRole : IdentityUserRole<string> {
	}

	/// <summary>
	/// EntityType that represents a user belonging to a role
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	public class IdentityUserRole<TKey> {

		/// <summary>
		/// RoleId for the role
		/// </summary>
		public virtual TKey RoleId { get; set; }

		/// <summary>
		/// UserId for the user that is in the role
		/// </summary>
		public virtual TKey UserId { get; set; }
	}
}
