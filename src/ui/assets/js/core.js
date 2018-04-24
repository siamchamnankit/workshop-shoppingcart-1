//Frontend
const getFrontendURL = (path = '') => `http://${location.host}/${path}`
const redirectToIndex = () => location.href = getFrontendURL();
const redirectToCart = (id = '') => location.href = getFrontendURL(`cart.html?id=${id}`);
//Backend
const getApiURL = (path = '') => `http://${location.host}:5001/${path}`