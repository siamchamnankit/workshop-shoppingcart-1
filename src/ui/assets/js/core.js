//Frontend
const getFrontendURL = (path = '') => `http://${location.host}/${path}`
const redirectToIndex = () => location.href = getFrontendURL();
//Backend
const getApiURL = (path = '') => `http://${location.host}:5001/${path}`