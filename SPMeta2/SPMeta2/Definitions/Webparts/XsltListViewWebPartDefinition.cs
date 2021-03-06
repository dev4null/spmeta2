﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;
using SPMeta2.Definitions.Base;
using SPMeta2.Utils;
using System.Runtime.Serialization;

namespace SPMeta2.Definitions.Webparts
{
    /// <summary>
    /// Allows to define and deploy 'XsltListView' web part.
    /// </summary>
    [SPObjectType(SPObjectModelType.SSOM, "System.Web.UI.WebControls.WebParts.WebPart", "System.Web")]
    [SPObjectType(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.WebParts.WebPart", "Microsoft.SharePoint.Client")]

    [DefaultRootHost(typeof(WebDefinition))]
    [DefaultParentHost(typeof(WebPartPageDefinition))]

    [Serializable]
    [DataContract]
    [ExpectArrayExtensionMethod]

    public class XsltListViewWebPartDefinition : WebPartDefinition
    {
        #region constructors

        public XsltListViewWebPartDefinition()
        {
            TitleUrl = string.Empty;
        }

        #endregion

        #region properties

        [ExpectValidation]
        [DataMember]
        public string ListTitle { get; set; }

        [ExpectValidation]
        [DataMember]
        public string ListUrl { get; set; }

        [ExpectValidation]
        [DataMember]
        public Guid? ListId { get; set; }

        [ExpectValidation]
        [DataMember]
        public string ViewName { get; set; }

        [ExpectValidation]
        [DataMember]
        public Guid? ViewId { get; set; }

        [ExpectValidation]
        [DataMember]
        public string JSLink { get; set; }

        [ExpectValidation]
        [DataMember]
        public string TitleUrl { get; set; }

        #endregion

        #region methods

        public override string ToString()
        {
            return new ToStringResult<XsltListViewWebPartDefinition>(this, base.ToString())
                          .AddPropertyValue(p => p.ListTitle)
                          .AddPropertyValue(p => p.ListUrl)
                          .AddPropertyValue(p => p.ListId)

                          .AddPropertyValue(p => p.ViewName)
                          .AddPropertyValue(p => p.ViewId)

                          .AddPropertyValue(p => p.JSLink)
                          .ToString();
        }

        #endregion
    }
}
