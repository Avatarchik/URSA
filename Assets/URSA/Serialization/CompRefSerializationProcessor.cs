﻿namespace URSA.Serialization {
    using UnityEngine;
    using System;
    using System.Collections.Generic;
    using FullSerializer;
    using URSA;

    public class CompRefSerializationProcessor : fsObjectProcessor {

        public static bool blueprint;

        public override void OnBeforeSerialize(Type storageType, object instance) {

            CompRef cref = instance as CompRef;
            ComponentBase comp = cref.target;
            if (comp != null) {
                cref.isNull = false;
                if (blueprint)
                    cref.entity_ID = comp.Entity.blueprint_ID;
                else
                    cref.entity_ID = comp.Entity.ID;

                cref.component_ID = comp.ID;
                cref.entityName = comp.Entity.name;
            }
            else {
                cref.isNull = true;

            }
            //cref.target = null;
        }
    }

}