using System;
using NUnit.Framework;
using SharpVectors.Dom;
using SharpVectors.Dom.Svg;
		
		[TestFixture]
		public class MutationEventTests_DOMCharacterDataModified
		{
			[Ignore("Mutation Events Not Implemented")]
			public void CommentNodeCreation()
			{
				Document document = new Document();
				document.MutationEvents = true;
				Comment comment = (Comment)document.CreateComment("comment");
				comment.Data = "trigger";
			}
		}
		
