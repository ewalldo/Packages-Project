namespace TooltipSystem
{
	public enum TooltipPosition
	{
		/// <summary>
		/// The tooltip will be displayed at the current mouse position and stays there
		/// </summary>
		AtMouseCursor,
		/// <summary>
		/// The tooltip will be displayed at the current mouse position and will follow it around
		/// </summary>
		FollowMouseCursor,
		/// <summary>
		/// The tooltip will be displayed at the transform position and will follow it around
		/// </summary>
		AtTransform,
		/// <summary>
		/// The tooltip will be displayed at the Vector3 position and stays there
		/// </summary>
		AtVector3,
	}
}