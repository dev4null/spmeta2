﻿using System;
using SPMeta2.Definitions;
using SPMeta2.Definitions.ContentTypes;
using SPMeta2.Models;
using SPMeta2.Syntax.Default.Extensions;

namespace SPMeta2.Syntax.Default
{
    public static class RemoveContentTypeLinksDefinitionSyntax
    {
        #region methods


        public static ModelNode AddRemoveContentTypeLinks(this ModelNode model, RemoveContentTypeLinksDefinition definition)
        {
            return AddRemoveContentTypeLinks(model, definition, null);
        }

        public static ModelNode AddRemoveContentTypeLinks(this ModelNode model, RemoveContentTypeLinksDefinition definition, Action<ModelNode> action)
        {
            return model.AddDefinitionNode(definition, action);
        }

        #endregion
    }
}
