<!-- eslint-disable vue/multi-word-component-names -->
<script lang="ts">
import type { IShortestPathResponseDto } from './../interfaces/index';
import api from '../services/api';

export default {
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
        console.log('Calculate button clicked')
        const response = await api.getShortestPath({ fromNode: this.fromNode, toNode: this.toNode })
        this.shortestPath = response.data
      } catch (error) {
        console.error('Error fetching items:', error)
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
        <div class="col-md-8 position-relative">
          <div class="card calculator-card shadow">
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

                    <button type="button" class="btn btn-sm btn-outline-warning" @click="clear">
                      Clear
                    </button>
                    <button type="button" class="btn btn-sm btn-warning mx-1" @click="calculate">
                      Calculate
                      <i class="bi bi-calculator"></i>
                    </button>
                  </form>
                  <code><pre>{{ { fromNode, toNode } }}</pre></code>
                </div>
                <div class="col">
                  <div class="d-flex align-items-center justify-content-around">
                    <svg height="200px" width="200px" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg"
                      xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 492.087 492.087" xml:space="preserve"
                      fill="#000000">
                      <g id="SVGRepo_bgCarrier" stroke-width="0"></g>
                      <g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g>
                      <g id="SVGRepo_iconCarrier">
                        <g>
                          <path style="fill: #005ece"
                            d="M420.022,75.299C373.551,28.827,311.764,3.234,246.043,3.234v40 c113.613,0,206.043,92.431,206.043,206.044v12.819c24.658,24.019,40,57.557,40,94.617V249.278 C492.087,183.557,466.494,121.77,420.022,75.299z">
                          </path>
                          <path style="fill: #2488ff"
                            d="M72.064,75.299C25.593,121.77,0,183.557,0,249.278v107.436h172.139V224.574h-40 c-35.802,0-68.318,14.319-92.139,37.522v-12.819c0-113.613,92.431-206.044,206.043-206.044v-40 C180.323,3.234,118.536,28.827,72.064,75.299z">
                          </path>
                          <path style="fill: #005ece"
                            d="M0,356.714c0,72.862,59.277,132.139,132.139,132.139h40V356.714H0z"></path>
                          <path style="fill: #00479b"
                            d="M452.087,262.097c-23.821-23.203-56.337-37.522-92.139-37.522h-40v132.139h172.139 C492.087,319.654,476.745,286.115,452.087,262.097z">
                          </path>
                          <path style="fill: #003068"
                            d="M319.948,356.714v132.139h40c72.862,0,132.139-59.277,132.139-132.139H319.948z"></path>
                        </g>
                      </g>
                    </svg>
                  </div>
                </div>
              </div>
              <div class="row m-2" v-if="shortestPath">
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
                      <li class="list-group-item my-1 rounded d-flex justify-content-between align-items-center" v-for="(ps, psindex) in shortestPath.pathSegments" :Key="ps">
                        <div>
                          <span class="badge text-bg-primary border rounded-pill">{{ (psindex + 1) }}</span>
                          From "{{ ps.fromNode }}" to "{{  ps.toNode }}"
                        </div>
                        <div class="fw-light small">Distance: {{ ps.distance }}</div>
                      </li>
                    </div>
                  </div>
                </div>
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
  /* Adjust the overlap */
}

.calculator-container {
  margin-top: -10rem;
  /* Further adjust to overlap with the header */
}
</style>
