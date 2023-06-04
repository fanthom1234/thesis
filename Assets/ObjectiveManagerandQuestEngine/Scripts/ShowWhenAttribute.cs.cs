using System;
using UnityEngine;

namespace ObjectiveManagerandQuestEngine
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ShowWhenAttribute : PropertyAttribute
	{

		public readonly string conditionFieldName;
		public readonly object comparationValue;
		public readonly object[] comparationValueArray;

		public ShowWhenAttribute(string conditionFieldName)
		{
			this.conditionFieldName = conditionFieldName;
		}

		public ShowWhenAttribute(string conditionFieldName, object comparationValue = null)
		{
			this.conditionFieldName = conditionFieldName;
			this.comparationValue = comparationValue;
		}

		public ShowWhenAttribute(string conditionFieldName, object[] comparationValueArray = null)
		{
			this.conditionFieldName = conditionFieldName;
			this.comparationValueArray = comparationValueArray;
		}
	}
}