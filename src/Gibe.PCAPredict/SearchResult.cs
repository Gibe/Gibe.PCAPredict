namespace Gibe.PCAPredict
{
	public class SearchResult
	{
		public SearchResult(string id, string text, string description, string highlight, string next)
		{
			Id = id;
			Text = text;
			Description = description;
			Highlight = highlight;
			Next = next;
		}

		public string Id { get; }

		public string Text { get; }
		public string Description { get; }
		public string Highlight { get; }
		public string Next { get; }

		public override string ToString()
		{
			return $"(SearchResult {Id} {Text} => {Next})";
		}

		protected bool Equals(SearchResult other)
		{
			return string.Equals(Id, other.Id) && string.Equals(Text, other.Text) &&
			       string.Equals(Description, other.Description) && string.Equals(Highlight, other.Highlight) &&
			       string.Equals(Next, other.Next);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((SearchResult) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id != null ? Id.GetHashCode() : 0;
				hashCode = (hashCode * 397) ^ (Text != null ? Text.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Highlight != null ? Highlight.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Next != null ? Next.GetHashCode() : 0);
				return hashCode;
			}
		}

		public static bool operator ==(SearchResult left, SearchResult right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(SearchResult left, SearchResult right)
		{
			return !Equals(left, right);
		}
	}
}