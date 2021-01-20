export interface projectModel {
    id: number
    title: string,
    description: string,
    displaySize: number,
    features: string[],
    githubLink: string,
    demoLink: string,
    images: Array<projectImage>,
}

export interface projectImage {
    id: number
    image: any,
    projectId: number
}