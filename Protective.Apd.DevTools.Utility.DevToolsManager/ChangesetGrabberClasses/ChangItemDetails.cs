using Microsoft.TeamFoundation.VersionControl.Client;

namespace DevToolsAndReferenceAnalyzer.ChangesetGrabberClasses
{
    /// <summary>
    /// Internal class containing details about a TFS changeset item.
    /// </summary>
    public sealed class ChangeItemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeItemDetails"/> class.
        /// </summary>
        /// <param name="change">The change.</param>
        public ChangeItemDetails(Change change)
        {
            ChangeType = change.ChangeType.ToString();
            ServerItem = change.Item.ServerItem;
            ItemType = change.Item.ItemType.ToString();
        }

        public string ChangeType { get; set; }

        public string ServerItem { get; set; }

        public string ItemType { get; set; }
    }
}
