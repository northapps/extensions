﻿import * as React from 'react'
import { classes } from '@framework/Globals'
import { FormGroup, FormControlReadonly, ValueLine, ValueLineType, EntityLine, EntityCombo, EntityList, EntityRepeater} from '@framework/Lines'
import {SearchControl }  from '@framework/Search'
import { TypeContext, FormGroupStyle } from '@framework/TypeContext'
import { PackageLineEntity, ProcessExceptionLineEntity } from '../Signum.Entities.Processes'

export default class Package extends React.Component<{ ctx: TypeContext<PackageLineEntity> }> {

    render() {
        
        const e = this.props.ctx.subCtx({readOnly: true});

        return (
            <div>    
                <EntityLine ctx={e.subCtx(f => f.package)}  />
                <EntityLine ctx={e.subCtx(f => f.target)}  />
                <EntityLine ctx={e.subCtx(f => f.result)}  />
                <ValueLine ctx={e.subCtx(f => f.finishTime)}  />
                <fieldset>
                    <legend>{ PackageLineEntity.nicePluralName() }</legend>
                    <SearchControl findOptions={{ queryName: ProcessExceptionLineEntity, parentColumn: "Line", parentValue : e.value}}  />
                </fieldset>
            </div>
        );
    }
}

