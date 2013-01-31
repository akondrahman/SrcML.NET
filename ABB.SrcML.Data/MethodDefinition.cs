﻿/******************************************************************************
 * Copyright (c) 2013 ABB Group
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    Vinay Augustine (ABB Group) - initial API, implementation, & documentation
 *    Patrick Francis (ABB Group) - initial API, implementation, & documentation
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ABB.SrcML.Data {
    public class MethodDefinition : NamedVariableScope {
        private Collection<VariableDeclaration> _parameters;

        public MethodDefinition() : base() {
            this._parameters = new Collection<VariableDeclaration>();
        }
        public AccessModifier Accessibility { get; set; }
        public bool IsConstructor { get; set; }
        public bool IsDestructor { get; set; }

        public Collection<TypeDefinition> InnerTypes;
        public Collection<VariableDeclaration> Parameters {
            get { return this._parameters; }
            set {
                var oldParameters = this._parameters;
                this._parameters = value;
                
                foreach(var parameter in oldParameters) {
                    this.DeclaredVariablesDictionary.Remove(parameter.Name);
                }
                
                foreach(var parameter in this._parameters) {
                    this.AddDeclaredVariable(parameter);
                }
            }
        }

        
    }
}
