export interface IShortestPathRequestDto {
  fromNode: string
  toNode: string
}

export interface IShortestPathResponseDto {
  nodeNames: string[]
  distance: number
  pathSegments: IPathSegmentDto[]
}

export interface IPathSegmentDto {
  fromNode: string
  toNode: string
  distance: number
}
