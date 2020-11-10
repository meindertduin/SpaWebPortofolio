export interface projectModel {
    title: string,
    description: string,
    displaySize: number,
    features: string[],
    githubLink: string,
    demoLink: string,
    images: Array<projectImage>,
}

export interface projectImage {
    image: any,
    projectId: number
}