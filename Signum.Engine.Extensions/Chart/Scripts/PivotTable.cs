
using Signum.Engine.Chart;
using Signum.Entities.Chart;
using System.Collections.Generic;

namespace Signum.Engine.Chart.Scripts 
{
    public class PivotTableScript : ChartScript                
    {
        public PivotTableScript() : base(HtmlChartScript.PivotTable)
        {
            this.Icon = ChartScriptLogic.LoadIcon("pivottable.png");
            this.Columns = new List<ChartScriptColumn>
            {
                new ChartScriptColumn("Horizontal", ChartColumnType.Groupable) { IsOptional = true },
                new ChartScriptColumn("Horizontal Axis (2)", ChartColumnType.Groupable) { IsOptional = true },
                new ChartScriptColumn("Horizontal Axis (3)", ChartColumnType.Groupable) { IsOptional = true },
                new ChartScriptColumn("Vertical Axis", ChartColumnType.Groupable){ IsOptional = true },
                new ChartScriptColumn("Vertical Axis (2)", ChartColumnType.Groupable){ IsOptional = true },
                new ChartScriptColumn("Vertical Axis (3)", ChartColumnType.Groupable){ IsOptional = true },
                new ChartScriptColumn("Value", ChartColumnType.Magnitude),
            };
            this.ParameterGroups = new List<ChartScriptParameterGroup>
            {
                CreateBlock("Complete ", ChartParameterType.Enum, EnumValueList.Parse("No|Yes|Consistent|FromFilters"), includeValues: false),
                CreateBlock("Order ", ChartParameterType.Enum, EnumValueList.Parse("None|Ascending|AscendingKey|AscendingToStr|AscendingSumValues|Descending|DescendingKey|DescendingToStr|DescendingSumValues"), includeValues: false),
                CreateBlock("Gradient ", ChartParameterType.Enum, EnumValueList.Parse("None|YlGn|YlGnBu|GnBu|BuGn|PuBuGn|PuBu|BuPu|RdPu|PuRd|OrRd|YlOrRd|YlOrBr|Purples|Blues|Greens|Oranges|Reds|Greys|PuOr|BrBG|PRGn|PiYG|RdBu|RdGy|RdYlBu|Spectral|RdYlGn"), includeValues: true),
                CreateBlock("Scale ", ChartParameterType.Enum, EnumValueList.Parse("ZeroMax|MinMax|Sqrt|Log"), includeValues: true),
                CreateBlock("text-align ", ChartParameterType.Enum, EnumValueList.Parse("center|start|end"), includeValues: true),
                CreateBlock("vert-align ", ChartParameterType.Enum, EnumValueList.Parse("top|middle|bottom"), includeValues: true),
                new ChartScriptParameterGroup()
                {
                    new ChartScriptParameter("Placeholder Vertical Axis", ChartParameterType.Enum) { ColumnIndex = 3, ValueDefinition = EnumValueList.Parse("no|empty|filled")},
                    new ChartScriptParameter("Placeholder Vertical Axis (2)", ChartParameterType.Enum) { ColumnIndex = 4, ValueDefinition = EnumValueList.Parse("no|empty|filled")},
                }
            };
        }

        private static ChartScriptParameterGroup CreateBlock(string prefix, ChartParameterType type, IChartParameterValueDefinition valueDefinition, bool includeValues)
        {
            var result = new ChartScriptParameterGroup()
            {
                new ChartScriptParameter(prefix + "Horizontal Axis", ChartParameterType.Enum) { ColumnIndex = 0, ValueDefinition = valueDefinition},
                new ChartScriptParameter(prefix + "Horizontal Axis (2)", ChartParameterType.Enum) { ColumnIndex = 1, ValueDefinition = valueDefinition},
                new ChartScriptParameter(prefix + "Horizontal Axis (3)", ChartParameterType.Enum) { ColumnIndex = 2, ValueDefinition = valueDefinition},
                new ChartScriptParameter(prefix + "Vertical Axis", ChartParameterType.Enum) { ColumnIndex = 3, ValueDefinition = valueDefinition},
                new ChartScriptParameter(prefix + "Vertical Axis (2)", ChartParameterType.Enum) { ColumnIndex = 4, ValueDefinition = valueDefinition},
                new ChartScriptParameter(prefix + "Vertical Axis (3)", ChartParameterType.Enum) { ColumnIndex = 5, ValueDefinition = valueDefinition},
            };

            if (includeValues)
            {
                result.Add(new ChartScriptParameter(prefix + "Values", ChartParameterType.Enum) { ColumnIndex = 6, ValueDefinition = valueDefinition });
            }
            return result;
        }
    }                
}
