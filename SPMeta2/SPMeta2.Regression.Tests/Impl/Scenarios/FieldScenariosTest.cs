﻿using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Containers;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Regression.Tests.Base;
using SPMeta2.Regression.Tests.Impl.Scenarios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SPMeta2.Syntax.Default;

namespace SPMeta2.Regression.Tests.Impl.Scenarios
{
    [TestClass]
    public class FieldScenariosTest : SPMeta2RegresionScenarioTestBase
    {
        #region constructors

        public FieldScenariosTest()
        {
            RegressionService.ProvisionGenerationCount = 2;
        }

        #endregion

        #region internal

        [ClassInitializeAttribute]
        public static void Init(TestContext context)
        {
            InternalInit();
        }

        [ClassCleanupAttribute]
        public static void Cleanup()
        {
            InternalCleanup();
        }

        #endregion

        #region raw XML

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields.RawXml")]
        public void CanDeploy_Field_WithRawXml()
        {
            WithDisabledPropertyUpdateValidation(() =>
            {
                var internalName = Rnd.String();
                var id = Guid.NewGuid();
                var title = Rnd.String();
                var group = Rnd.String();

                var xmlElement = new XElement("Field",
                    new XAttribute(BuiltInFieldAttributes.ID, id.ToString("B")),
                    new XAttribute(BuiltInFieldAttributes.StaticName, internalName),
                    new XAttribute(BuiltInFieldAttributes.DisplayName, title),
                    new XAttribute(BuiltInFieldAttributes.Title, title),
                    new XAttribute(BuiltInFieldAttributes.Name, internalName),
                    new XAttribute(BuiltInFieldAttributes.Type, BuiltInFieldTypes.Text),
                    new XAttribute(BuiltInFieldAttributes.Group, group));

                var def = ModelGeneratorService.GetRandomDefinition<FieldDefinition>();

                // ID/InternalName should be defined to be able to lookup the field 
                def.Id = id;
                def.FieldType = BuiltInFieldTypes.Text;
                def.InternalName = internalName;
                def.Title = title;
                def.Group = group;

                def.RawXml = xmlElement.ToString();

                var siteModel = SPMeta2Model.NewSiteModel(site =>
                {
                    site.AddField(def);
                });

                TestModel(siteModel);
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields.RawXml")]
        public void CanDeploy_Field_WithRawXmlAndAdditionalAttributes()
        {
            WithDisabledPropertyUpdateValidation(() =>
            {
                var internalName = Rnd.String();
                var id = Guid.NewGuid();
                var title = Rnd.String();
                var group = Rnd.String();

                var xmlElement = new XElement("Field",
                    new XAttribute(BuiltInFieldAttributes.ID, id.ToString("B")),
                    new XAttribute(BuiltInFieldAttributes.StaticName, internalName),
                    new XAttribute(BuiltInFieldAttributes.DisplayName, title),
                    new XAttribute(BuiltInFieldAttributes.Title, title),
                    new XAttribute(BuiltInFieldAttributes.Name, internalName),
                    new XAttribute(BuiltInFieldAttributes.Type, BuiltInFieldTypes.Text),
                    new XAttribute(BuiltInFieldAttributes.Group, group));

                var def = ModelGeneratorService.GetRandomDefinition<FieldDefinition>();

                // ID/InternalName should be defined to be able to lookup the field 
                def.Id = id;
                def.FieldType = BuiltInFieldTypes.Text;
                def.InternalName = internalName;
                def.Title = title;
                def.Group = group;

                def.RawXml = xmlElement.ToString();

                def.AdditionalAttributes.Add(new FieldAttributeValue("Commas", Rnd.Bool().ToString().ToUpper()));
                def.AdditionalAttributes.Add(new FieldAttributeValue("AllowDuplicateValues",
                    Rnd.Bool().ToString().ToUpper()));

                var siteModel = SPMeta2Model.NewSiteModel(site =>
                {
                    site.AddField(def);
                });

                TestModel(siteModel);
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields.Attributes")]
        public void CanDeploy_Field_WithAdditionalAttributes()
        {
            var def = ModelGeneratorService.GetRandomDefinition<FieldDefinition>();

            def.AdditionalAttributes.Add(new FieldAttributeValue("Commas", Rnd.Bool().ToString().ToUpper()));
            def.AdditionalAttributes.Add(new FieldAttributeValue("AllowDuplicateValues", Rnd.Bool().ToString().ToUpper()));

            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddField(def);
            });

            TestModel(siteModel);
        }

        #endregion

        #region default

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_BooleanField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Boolean;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_CalculatedField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Calculated;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_ChoiceField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Choice;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_ComputedField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Computed;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_CurrencyField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Currency;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_DateTimeField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.DateTime;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_GeolocationField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Geolocation;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_GuidField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Guid;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_LookupField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Lookup;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_MultiChoiceField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.MultiChoice;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_NoteField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Note;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_NumberField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Number;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_OutcomeChoiceField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.OutcomeChoice;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_TaxonomyFieldTypeField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.TaxonomyFieldType;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_TaxonomyFieldTypeMultiField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.TaxonomyFieldTypeMulti;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_TextField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.Text;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_URLField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.URL;
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields")]
        public void CanDeploy_UserField()
        {
            TestRandomDefinition<FieldDefinition>(def =>
            {
                def.FieldType = BuiltInFieldTypes.User;
            });
        }

        #endregion

        #region field scopes

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields.Scopes")]
        public void CanDeploy_SiteScoped_Field()
        {
            var field = ModelGeneratorService.GetRandomDefinition<FieldDefinition>();

            var model = SPMeta2Model
                   .NewSiteModel(site =>
                   {
                       site.AddField(field);
                   });

            TestModel(model);
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields.Scopes")]
        public void CanDeploy_WebScoped_Field()
        {
            var field = ModelGeneratorService.GetRandomDefinition<FieldDefinition>();

            var model = SPMeta2Model
                   .NewWebModel(web =>
                   {
                       web.AddRandomWeb(subWeb =>
                       {
                           subWeb.AddField(field);
                       });
                   });

            TestModel(model);
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields.Scopes")]
        public void CanDeploy_ListScoped_Field()
        {
            var field = ModelGeneratorService.GetRandomDefinition<FieldDefinition>();

            var model = SPMeta2Model
                   .NewWebModel(web =>
                   {
                       web.AddRandomList(list =>
                       {
                           list.AddField(field);
                       });
                   });

            TestModel(model);
        }


        #endregion

        #region field options

        [TestMethod]
        [TestCategory("Regression.Scenarios.Fields.Options")]
        public void CanDeploy_ListScopedField_AsAddToDefaultView()
        {
            var field = ModelGeneratorService.GetRandomDefinition<FieldDefinition>();

            field.AddToDefaultView = true;

            var model = SPMeta2Model
                   .NewWebModel(web =>
                   {
                       web.AddRandomList(list =>
                       {
                           list.AddField(field);
                       });
                   });

            TestModel(model);
        }

        #endregion
    }
}
