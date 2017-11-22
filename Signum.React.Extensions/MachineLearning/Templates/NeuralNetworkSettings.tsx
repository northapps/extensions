﻿import * as React from 'react'
import { classes } from '../../../../Framework/Signum.React/Scripts/Globals'
import { FormGroup, FormControlStatic, ValueLine, ValueLineType, EntityLine, EntityCombo, EntityList, EntityRepeater, EntityTable, StyleContext } from '../../../../Framework/Signum.React/Scripts/Lines'
import { SearchControl, ValueSearchControl } from '../../../../Framework/Signum.React/Scripts/Search'
import { TypeContext, FormGroupStyle } from '../../../../Framework/Signum.React/Scripts/TypeContext'
import FileLine from '../../Files/FileLine'
import { NeuralNetworkSettingsEntity, PredictorEntity, PredictorColumnUsage, PredictorCodificationEntity, NeuralNetworkHidenLayerEmbedded } from '../Signum.Entities.MachineLearning'
import * as Finder from '../../../../Framework/Signum.React/Scripts/Finder'
import { getQueryNiceName } from '../../../../Framework/Signum.React/Scripts/Reflection'
import QueryTokenEntityBuilder from '../../UserAssets/Templates/QueryTokenEntityBuilder'
import { QueryTokenEmbedded } from '../../UserAssets/Signum.Entities.UserAssets'
import { QueryFilterEmbedded } from '../../UserQueries/Signum.Entities.UserQueries'
import { QueryDescription, SubTokensOptions } from '../../../../Framework/Signum.React/Scripts/FindOptions'
import { API } from '../PredictorClient';
import FilterBuilderEmbedded from './FilterBuilderEmbedded';
import { TypeReference } from '../../../../Framework/Signum.React/Scripts/Reflection';

export default class NeuralNetworkSettings extends React.Component<{ ctx: TypeContext<NeuralNetworkSettingsEntity> }> {

    render() {
        const ctx = this.props.ctx;

        var p = ctx.findParent(PredictorEntity);

        const ctx2 = ctx.subCtx({ formGroupStyle: "Basic" })

        return (
            <div>
                <h4>{NeuralNetworkSettingsEntity.niceName()}</h4>
                <ValueLine ctx={ctx.subCtx(a => a.predictionType)} />
                {this.renderCount(ctx, p, "Input")}
                <EntityTable ctx={ctx.subCtx(a => a.hiddenLayers)} columns={EntityTable.typedColumns<NeuralNetworkHidenLayerEmbedded>([
                    { property: a => a.size, headerHtmlAttributes: { style: { width: "50%" } } },
                    { property: a => a.activation, headerHtmlAttributes: { style: { width: "50%" } } },
                ])} />
                <div className="form-vertical">
                    <div className="row">
                        <div className="col-sm-6">
                            {this.renderCount(ctx2, p, "Output")}
                        </div>
                        <div className="col-sm-6">
                            <ValueLine ctx={ctx2.subCtx(a => a.outputActivation)} />
                        </div>
                    </div>
                    <hr />
                    <div className="row">
                        <div className="col-sm-6">
                            <ValueLine ctx={ctx2.subCtx(a => a.learningRate)} />
                        </div>
                        <div className="col-sm-6">
                            <ValueLine ctx={ctx2.subCtx(a => a.learningMomentum)} />
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-sm-6">
                            <ValueLine ctx={ctx2.subCtx(a => a.minibatchSize)} />
                        </div>
                        <div className="col-sm-6">
                            <ValueLine ctx={ctx2.subCtx(a => a.numMinibatches)} />
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-sm-6">
                            <ValueLine ctx={ctx2.subCtx(a => a.saveProgressEvery)} />
                        </div>
                        <div className="col-sm-6">
                            <ValueLine ctx={ctx2.subCtx(a => a.saveValidationProgressEvery)} />
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    renderCount(ctx: StyleContext, p: PredictorEntity, usage: PredictorColumnUsage) {
        return (
            <FormGroup ctx={ctx} labelText={PredictorColumnUsage.niceName(usage) + " columns"}>
                {p.state != "Trained" ? <FormControlStatic ctx={ctx}>?</FormControlStatic> : <ValueSearchControl isBadge={true} isLink={true} findOptions={{
                    queryName: PredictorCodificationEntity,
                    parentColumn: "Predictor",
                    parentValue: p,
                    filterOptions: [
                        { columnName: "Usage", value: usage }
                    ]
                }} />}
            </FormGroup>
        );
    }
}