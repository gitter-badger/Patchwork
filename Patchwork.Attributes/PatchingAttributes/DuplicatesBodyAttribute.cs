﻿using System;

namespace Patchwork.Attributes {
	/// <summary>
	///     Inserts the body of another method into this method (as it appears in the game assembly). You must also decorate
	///     this method with NewMember/ModifiesMember.
	/// </summary>
	/// <remarks>
	///     Note that this attribute can be used to call the original versions of modified methods,
	///     as methods aren't resolved through the modifies assembly.
	/// </remarks>
	[AttributeUsage(AttributeTargets.Method)]
	public class DuplicatesBodyAttribute : PatchingAttribute {
		/// <summary>
		///     Initializes a new instance of the <see cref="DuplicatesBodyAttribute" /> class.
		/// </summary>
		/// <param name="methodName">Name of the method to duplicate. Required.</param>
		/// <param name="sourceType">
		///     Optionally, the declaring type. Otherwise, the type currently being modified is assumed. This
		///     parameter is an object due to a workraround.
		/// </param>
		public DuplicatesBodyAttribute(string methodName, object sourceType = null) {
			//this is a hack, but it seems like a pretty reliable one.
			if (sourceType != null && !sourceType.GetType().Name.Contains("Type")) {

				//The reason the parameter can't be 'Type', is that Cecil reads a System.Type parameter as a TypeReference,
				//since reading it as System.Type would require loading the assembly the type is defined in.
				//And we want to be able to instantiate this attribute from its Cecil.CustomAttribute metadata.
				throw new ArgumentException("This parameter must be a type of some sort.", "sourceType");
			}
			SourceType = sourceType;
			MethodName = methodName;
		}

		/// <summary>
		///     Gets the type which is the source of the method to be duplicated.  May be null.
		///     If acquired from Cecil, it will be a TypeReference, while if acquired through reflection, it will be a System.Type.
		/// </summary>
		/// <value>
		///     The type of the source.
		/// </value>
		public object SourceType { get; private set; }

		public string MethodName { get; private set; }
	}
}