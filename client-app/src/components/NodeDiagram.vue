<!-- Reference -->
<!-- https://dash14.github.io/v-network-graph/examples/basic.html -->
<!-- eslint-disable vue/multi-word-component-names -->
<script lang="ts">
import { VNetworkGraph } from 'v-network-graph';
import * as vNG from "v-network-graph"
import 'v-network-graph/lib/style.css';

export default {
    components: {
        VNetworkGraph,
    },
    data() {
        return {
            config: vNG.defineConfigs({
                node: {
                    selectable: true,
                    normal: {
                        type: "circle",
                        radius: 16,
                        // for type is "rect" -->
                        width: 32,
                        height: 32,
                        borderRadius: 4,
                        // <-- for type is "rect"
                        strokeWidth: 0,
                        strokeColor: "#000000",
                        strokeDasharray: "0",
                        color: "#4466cc",
                    },
                    hover: {
                        type: "circle",
                        radius: 16,
                        // for type is "rect" -->
                        width: 32,
                        height: 32,
                        borderRadius: 4,
                        // <-- for type is "rect"
                        strokeWidth: 0,
                        strokeColor: "#000000",
                        strokeDasharray: "0",
                        color: "#dd2288",
                    },
                    selected: {
                        type: "circle",
                        radius: 16,
                        // for type is "rect" -->
                        width: 32,
                        height: 32,
                        borderRadius: 4,
                        // <-- for type is "rect"
                        strokeWidth: 0,
                        strokeColor: "#000000",
                        strokeDasharray: "0",
                        color: "#4466cc",
                    },
                    label: {
                        visible: true,
                        fontFamily: undefined,
                        fontSize: 11,
                        lineHeight: 1.1,
                        color: "#000000",
                        margin: 4,
                        direction: "south",
                        background: {
                            visible: false,
                            color: "#ffffff",
                            padding: {
                                vertical: 1,
                                horizontal: 4,
                            },
                            borderRadius: 2,
                        },
                    },
                    focusring: {
                        visible: true,
                        width: 4,
                        padding: 3,
                        color: "#eebb00",
                        dasharray: "0",
                    },
                },
                edge: {
                    selectable: true,
                    normal: {
                        width: 1,
                        color: "#4466cc",
                        dasharray: "0",
                        linecap: "butt",
                        animate: false,
                        animationSpeed: 50,
                    },
                    hover: {
                        width: 3,
                        color: "#3355bb",
                        dasharray: "0",
                        linecap: "butt",
                        animate: false,
                        animationSpeed: 50,
                    },
                    selected: {
                        width: 2,
                        color: "#dd8800",
                        dasharray: "6",
                        linecap: "round",
                        animate: false,
                        animationSpeed: 50,
                    },
                    gap: 3,
                    type: "straight",
                    summarize: true,
                    summarized: {
                        label: {
                            fontSize: 10,
                            color: "#4466cc",
                        },
                        shape: {
                            type: "rect",
                            radius: 6, // for type is "circle"
                            width: 12,
                            height: 12,
                            borderRadius: 3,
                            color: "#ffffff",
                            strokeWidth: 1,
                            strokeColor: "#4466cc",
                            strokeDasharray: "0",
                        },
                        stroke: {
                            width: 5,
                            color: "#4466cc",
                            dasharray: "0",
                            linecap: "butt",
                            animate: false,
                            animationSpeed: 50,
                        },
                    },
                    marker: {
                        source: {
                            type: "none",
                            width: 2,
                            height: 2,
                            margin: -1,
                            offset: 0,
                            units: "strokeWidth",
                            color: null,
                        },
                        target: {
                            type: "arrow",
                            width: 5,
                            height: 6,
                            margin: -1,
                            offset: 0,
                            units: "strokeWidth",
                            color: null,
                        },
                    },
                },
            }),
            nodes: {
                A: { name: "A" },
                B: { name: "B" },
                C: { name: "C" },
                D: { name: "D" },
                E: { name: "E" },
                F: { name: "F" },
                G: { name: "G" },
                H: { name: "H" },
                I: { name: "I" },
            },
            edges: {
                edgeAB: { source: "A", target: "B" },
                edgeBA: { source: "B", target: "A" },
                edgeAC: { source: "A", target: "C" },
                edgeCA: { source: "C", target: "A" },
                edgeBF: { source: "B", target: "F" },
                edgeFB: { source: "F", target: "B" },
                edgeCD: { source: "C", target: "D" },
                edgeDC: { source: "D", target: "C" },
                edgeDE: { source: "D", target: "E" },
                edgeED: { source: "E", target: "D" },
                edgeEB: { source: "E", target: "B" },
                edgeEF: { source: "E", target: "F" },
                edgeFE: { source: "F", target: "E" },
                edgeFH: { source: "F", target: "H" },
                edgeHF: { source: "H", target: "F" },
                edgeFG: { source: "F", target: "G" },
                edgeGF: { source: "G", target: "F" },
                edgeGI: { source: "G", target: "I" },
                edgeIG: { source: "I", target: "G" },
                edgeIE: { source: "I", target: "E" },
                edgeEI: { source: "E", target: "I" },
                edgeHG: { source: "H", target: "G" },
                edgeGH: { source: "G", target: "H" },
                edgeDG: { source: "D", target: "G" },
                edgeGD: { source: "G", target: "D" },
            },
            layouts: {
                nodes: {
                    A: { x: -38, y: 29 },
                    B: { x: 37, y: -5 },
                    C: { x: 36, y: 94 },
                    D: { x: 123, y: 94 },
                    E: { x: 83, y: 48 },
                    F: { x: 118, y: -5 },
                    G: { x: 191, y: 94 },
                    H: { x: 237, y: -5 },
                    I: { x: 285, y: 60 }
                },
            },
            eventHandlers: {
                "node:click": ({ node }) => {
                    console.log(node);

                    // this.nodes[node].active = !this.nodes[node].active;
                }
            } as vNG.EventHandlers
        }
    },
    methods: {
    }
}
</script>

<template>
    <v-network-graph :nodes="nodes" :edges="edges" :layouts="layouts" :configs="config" :event-handlers="eventHandlers">
    </v-network-graph>
    <!-- <code><pre>{{ nodes }}</pre></code>
    <code><pre>{{ edges }}</pre></code> -->
</template>

<style scoped></style>