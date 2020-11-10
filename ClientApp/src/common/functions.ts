export function concatFeaturesString(features: string[]):string{
    let featuresString = "";

    for (let i = 0; i < features.length; i++){
        if (i + 1 !== features.length){
            featuresString += features[i] + ', ';
        }
        else{
            featuresString += features[i]
        }
    }
    return featuresString;
}