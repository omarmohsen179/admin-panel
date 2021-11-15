import axios from "axios";
import { ErpApiBaseUrl } from "./config.json";
/**
 * Create an Axios Client with defaults
 */
console.log(
  localStorage.getItem("user")
    ? `bearer ${JSON.parse(localStorage.getItem("user")).token}`
    : ""
);
export const client = axios.create({
  baseURL: ErpApiBaseUrl + "/api/",

  // baseURL: "https://localhost:44351/api"
  // baseURL: "https://api.eg-sds.com/api"
  // baseURL: "https://api.lms.almedadsoft.com/api"
  // baseURL: "http://192.168.1.5:5566/api"
});

/**
 * Request Wrapper with default success/error actions
 */
const REQUEST = function (options) {
  const onSuccess = function (response) {
    // console.debug('Request Successful!', response);
    return response.data;
  };

  const onError = function (error) {
    // console.error('Request Failed:', error.config);

    if (error.response) {
      // Request was made but server responded with something
      // other than 2xx
      // console.error('Status:', error.response.status);
      if (error.response.status === 401) {
        window.href = "/log-in";
        //  localStorage.removeItem("user");
        //window.location.reload();
      }
      // console.error('Data:', error.response.data);
      // console.error('Headers:', error.response.headers);
    } else {
      // Something else happened while setting up the REQUEST
      // triggered the error
      // console.error('Error Message:', error.message);
    }

    return Promise.reject(error);
  };
  console.log(JSON.parse(localStorage.getItem("user")));
  return client({
    ...options,
    headers: {
      ...axios.defaults.headers,
      Authorization: localStorage.getItem("user")
        ? `bearer ${JSON.parse(localStorage.getItem("user")).token}`
        : "",
    },
  })
    .then(onSuccess)
    .catch(onError);
};

export default REQUEST;
