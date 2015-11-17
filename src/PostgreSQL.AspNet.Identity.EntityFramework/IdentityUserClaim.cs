namespace PostgreSQL.AspNet.Identity.EntityFramework {

	/// <summary>
	/// EntityType that represents one specific user claim
	/// </summary>
	public class IdentityUserClaim : IdentityUserClaim<string> {
	}

	/// <summary>
	/// EntityType that represents one specific user claim
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	public class IdentityUserClaim<TKey> {

		/// <summary>
		/// Claim type
		/// </summary>
		public virtual string ClaimType { get; set; }

		/// <summary>
		/// Claim value
		/// </summary>
		public virtual string ClaimValue { get; set; }

		/// <summary>
		/// Primary key
		/// </summary>
		public virtual int Id { get; set; }

		/// <summary>
		/// User Id for the user who owns this login
		/// </summary>
		public virtual TKey UserId { get; set; }
	}
}
