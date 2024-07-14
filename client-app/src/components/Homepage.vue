<!-- eslint-disable vue/multi-word-component-names -->
<script lang="ts">
import type { IShortestPathResponseDto } from './../interfaces/index';
import toastService from '../services/toastService';
import api from '../services/api';
import PathDetailCard from './PathDetailCard.vue';
import IconTooling from './icons/IconTooling.vue';

export default {
  components: {
    PathDetailCard,
    IconTooling
  },
  data() {
    return {
      nodes: [...Array(26)].map((_, i) => String.fromCharCode(i + 65)),
      fromNode: '' as string,
      toNode: '' as string,
      shortestPath: null as IShortestPathResponseDto | null
    }
  },
  methods: {
    clear() {
      this.fromNode = ''
      this.toNode = ''
      this.shortestPath = null
    },
    async calculate() {
      try {
        if (!this.fromNode || !this.toNode) return toastService.warning('Invalid submittion. Please check your form.');
        const response = await api.getShortestPath({ fromNode: this.fromNode, toNode: this.toNode })
        this.shortestPath = response.data
      } catch (error: any) {
        console.error(error)
        toastService.error(error?.response?.data?.message);
      }
    }
  }
}
</script>

<template>
  <div>
    <div class="header text-white text-center d-flex flex-column justify-content-center">
      <h4>Dijkstra's Algorithm Calculator</h4>
      <p>Discovering Optimal Routes Through Nodes Using Dijkstra's Method</p>
    </div>
    <div class="container">

      <div class="row justify-content-center">
        <div class="col-md-8">
          <div class="card shadow-lg">
            <div class="card-body">
              <div class="row">
                <div class="col-lg-6 col-sm-12">
                  <h6 class="card-title text-primary fw-bold">Select Path</h6>
                  <form>
                    <div class="mb-3">
                      <label for="fromNode" class="form-label">From Node</label>
                      <select class="form-select form-control-sm" id="fromNode" v-model="fromNode">
                        <option value="">Select</option>
                        <option v-for="node in nodes" :key="node">{{ node }}</option>
                      </select>
                    </div>
                    <div class="mb-3">
                      <label for="toNode" class="form-label">To Node</label>
                      <select class="form-select form-control-sm" id="toNode" v-model="toNode">
                        <option value="">Select</option>
                        <option v-for="node in nodes" :key="node">{{ node }}</option>
                      </select>
                    </div>

                    <button type="button" class="btn btn-sm btn-outline-orange" @click="clear">
                      Clear
                    </button>
                    <button type="button" class="btn btn-sm btn-orange mx-1" @click="calculate">
                      Calculate
                      <i class="bi bi-calculator"></i>
                    </button>
                  </form>
                  <!-- <code><pre>{{ { fromNode, toNode } }}</pre></code> -->
                </div>
                <div class="col d-none d-lg-block">
                  <div class="d-flex align-items-center justify-content-around">
                    <IconTooling />
                  </div>
                </div>
              </div>
              <div class="row m-2" v-if="shortestPath">
                <PathDetailCard :shortest-path="shortestPath" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.header {
  background-color: #0056b3;
  height: 35vh;
}

.container {
  margin-top: -4rem;
}
</style>
