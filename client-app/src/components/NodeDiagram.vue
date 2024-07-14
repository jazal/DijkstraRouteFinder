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
                        width: 3,
                        color: "#4466cc",
                        dasharray: "0",
                        linecap: "butt",
                        animate: false,
                        animationSpeed: 50,
                    },
                    hover: {
                        width: 4,
                        color: "#3355bb",
                        dasharray: "0",
                        linecap: "butt",
                        animate: false,
                        animationSpeed: 50,
                    },
                    selected: {
                        width: 3,
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
                },
            }),
            xnodes: {
                nodeA: { name: "A" },
                nodeB: { name: "B" },
                nodeC: { name: "C" },
                nodeD: { name: "D" },
                nodeE: { name: "E" },
                nodeF: { name: "F" },
                nodeG: { name: "G" },
                nodeH: { name: "H" },
                nodeI: { name: "I" },
            },
            edges: {
                edge1: { source: "nodeA", target: "nodeB", dis: "4" },
                edge2: { source: "nodeA", target: "nodeC" },
                edge3: { source: "nodeB", target: "nodeF" },
                edge4: { source: "nodeC", target: "nodeD" },
                edge5: { source: "nodeD", target: "nodeE" },
                edge6: { source: "nodeE", target: "nodeB" },
                edge7: { source: "nodeE", target: "nodeF" },
                edge8: { source: "nodeF", target: "nodeH" },
                edge9: { source: "nodeF", target: "nodeG" },
                edge10: { source: "nodeG", target: "nodeI" },
                edge11: { source: "nodeI", target: "nodeE" },
                edge12: { source: "nodeH", target: "nodeG" },
                edge13: { source: "nodeD", target: "nodeG" },
            },
            layouts: {
                nodes: {
                    nodeA: { x: -38, y: 29 },
                    nodeB: { x: 37, y: -5 },
                    nodeC: { x: 36, y: 94 },
                    nodeD: { x: 123, y: 94 },
                    nodeE: { x: 83, y: 48 },
                    nodeF: { x: 118, y: -5 },
                    nodeG: { x: 191, y: 94 },
                    nodeH: { x: 237, y: -5 },
                    nodeI: { x: 285, y: 60 }
                },
            }
        }
    },
    methods: {

    }
}
</script>

<template>
    <v-network-graph :nodes="xnodes" :edges="edges" :layouts="layouts" :configs="config" />
    <!-- <code><pre>{{ layouts }}</pre></code> -->
</template>

<style scoped></style>