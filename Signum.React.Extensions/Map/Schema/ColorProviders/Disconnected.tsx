﻿import * as React from 'react'
import * as d3 from 'd3'
import { ClientColorProvider, TableInfo  } from '../SchemaMap'
import { colorScale, colorScaleSqr  } from '../../Utils'
import { Upload, Download  } from '../../../Disconnected/Signum.Entities.Disconnected'
export default function getDefaultProviders(info: TableInfo[]): ClientColorProvider[] {

    return [
        {
            name: "disconnected",
            getFill: t => t.extra["disc-upload"] == null ? "white" : "url(#disconnected-" + t.extra["disc-upload"] + "-" + t.extra["disc-download"] + ")",
            getTooltip: t => t.extra["disc-upload"] == null ? "" : "Download " + t.extra["disc-download"] + " - " + "Upload " + t.extra["disc-upload"],
            defs: info.groupBy(t => (t.extra["disc-upload"] || "None") + "-" + (t.extra["disc-download"] || "None"))
                .map(gr => gradientDef(gr.key.before("-"), gr.key.after("-")))
        }
    ];
}

function gradientDef(upload, download) {
    return (
        <linearGradient id={grandientName(upload, download) } x1="0% " y1="0% " x2="0% " y2="100%">
            <stop offset="0% " stopColor={uploadColor(upload) } />
            <stop offset="100% " stopColor={ downloadColor(download) } />
        </linearGradient >
    );
}

function grandientName(upload: Upload, download: Download) {
    return "disconnected-" + upload + "-" + download;
}

function downloadColor(download: Download): string {
    switch (download) {
        case "None": return "#ccc";
        case "All": return "red";
        case "Subset": return "gold";
        case "Replace": return "#CC0099";
        default: throw new Error();
    }
}

function uploadColor(upload: Upload): string {
    switch (upload) {
        case "None": return "#ccc";
        case "New": return "green";
        case "Subset": return "gold";
        default: throw new Error();
    }
}