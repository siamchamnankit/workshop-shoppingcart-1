//Frontend
const getFrontendURL = (path = '') => `http://${location.host}/${path}`
const redirectToIndex = () => location.href = getFrontendURL();
const redirectToCart = () => location.href = getFrontendURL('cart.html');
//Backend
const getApiURL = (path = '') => `http://${location.host}:5001/${path}`