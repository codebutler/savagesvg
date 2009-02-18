using System;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace SharpVectors.Xml
{
  /// <summary>
  /// Used to redirect external DTDs to local copies.
  /// </summary>
  public class LocalDtdXmlUrlResolver : XmlUrlResolver
  {
    public LocalDtdXmlUrlResolver(): base()
    {
    }

    private Hashtable knownDtds = new Hashtable();
    private Hashtable ignorePatterns = new Hashtable();

    public void AddDtd(string publicIdentifier, string localFile)
    {
      knownDtds.Add(publicIdentifier, localFile);
    }

    public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn) 
    { 
      if (absoluteUri != null && knownDtds.ContainsKey(absoluteUri.AbsoluteUri))
      {
        // ignore the known DTDs
        return Stream.Null; 
      }
      else if (absoluteUri == null) 
      {
        // ignore null URIs
        return Stream.Null;
      } 
      else 
      {
        return base.GetEntity(absoluteUri, role, ofObjectToReturn);
      }
    }

    public override Uri ResolveUri(Uri baseUri, string relativeUri)
    {
      if (relativeUri.StartsWith("#"))
        return null;
      else if (relativeUri.IndexOf("-//") > -1) 
        return null;
      else
        return base.ResolveUri(baseUri, relativeUri);
    }
  }
}
