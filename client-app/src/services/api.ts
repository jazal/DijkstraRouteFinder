import type { IShortestPathRequestDto, IShortestPathResponseDto } from '@/interfaces'
import axios from 'axios'

const apiClient = axios.create({
  baseURL: 'https://localhost:7134/api', // Base URL of your .NET Core API
  withCredentials: false,
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json'
  }
})

export default {
  getItems() {
    return apiClient.get('/items')
  },

  getShortestPath(payload: IShortestPathRequestDto) {
    return apiClient.post<IShortestPathResponseDto>('/ShortestPath', payload)
  }
}
