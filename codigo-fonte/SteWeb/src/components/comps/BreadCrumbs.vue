<template>
    <div class="flex breadcrumb">
        <div>
            <RouterLink to="/">Home</RouterLink>
            <span v-if="breadcrumbName"> / {{ breadcrumbName }}</span>
        </div>
    </div>
</template>

<script>
export default {
    computed: {
        breadcrumbName() {
            return this.$route.meta.breadcrumb || '';
        }
    }
};
</script>
<style>
.breadcrumb {
align-items: left;
border-bottom: .1rem solid #fff;
}
</style>
