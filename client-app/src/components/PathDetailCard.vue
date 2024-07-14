<template>
    <div class="card bg-secondary-subtle">
        <div class="card-body">
            <div class="d-flex justify-content-between small text-primary mb-3">
                <div>Total Steps
                    <div class="fw-bold">{{ shortestPath.pathSegments.length }}</div>
                </div>
                <div>Total Distance
                    <div class="fw-bold text-right">{{ shortestPath.distance }}</div>
                </div>
            </div>
            <div class="list-group">
                <li class="list-group-item my-1 rounded d-flex justify-content-between align-items-center"
                    v-for="(ps, psindex) in shortestPath.pathSegments" :Key="ps">
                    <div>
                        <span class="badge text-bg-primary border rounded-pill">{{ (psindex + 1) }}</span>
                        From "{{ ps.fromNode }}" to "{{ ps.toNode }}"
                    </div>
                    <div class="fw-light small">Distance: {{ ps.distance }}</div>
                </li>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
export default {
    name: 'PathDetailCard',
    props: {
        shortestPath: {
            type: Object,
            required: true
        }
    }
}
</script>

<style scoped></style>